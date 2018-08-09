using System;
using System.Collections.Generic;
using System.Text;

namespace Hamburger.Domain.Events
{
    public interface IEventStore
    {
        void saveEvents(Guid Id, HamburgerCreatedEvent events, int exprectedVersion);
        List<HamburgerCreatedEvent> GetEvents(Guid id);
    }
    public class EventStore
    {
        
    }
}
