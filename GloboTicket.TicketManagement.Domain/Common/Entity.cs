using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloboTicket.TicketManagement.Domain.Common
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(long id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetUnproxiedType(this) != GetUnproxiedType(other))
                return false;

            if (Id.Equals(default) || other.Id.Equals(default))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetUnproxiedType(this).ToString() + Id).GetHashCode();
        }

        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
        
        [NotMapped]
        private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new ConcurrentQueue<IDomainEvent>();

        [NotMapped]
        public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void PublishEvent(IDomainEvent @event)
        {
            _domainEvents.Enqueue(@event);
        }

        protected Guid newIdGuid()
        {
            return Guid.Empty;
            // MassTransit.NewId.NextGuid();
        }
    }
}