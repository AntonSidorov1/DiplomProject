using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopDesktopApp
{
    public class SessionEditList : List<SessionEdit>
    {
        public SessionEditList()
        {
            RemovingOld = false;
        }

        public SessionEditList(IEnumerable<SessionEdit> collection) : base(collection)
        {
            RemovingOld = false;
        }

        public SessionEditList(int capacity) : base(capacity)
        {
            RemovingOld = false;
        }

        public new SessionEditList FindAll(Predicate<SessionEdit> predicate)
        {
            return new SessionEditList(base.FindAll(predicate));
        }

        public SessionEditList Copy() => new SessionEditList(this);

        public SessionEditList GetThis() => this;

        public SessionEditList Find(bool allowEditConnection)
        {
            if (RemovingOld)
                RemoveOld();
            return FindAll(session => session.AllowEditConnection == allowEditConnection);
        }
        public SessionEditList FindAllowEditConnection() => Find(true);

        public void Remove(string session)
        {
            int index = FindIndex(s => s.Session == session);
            while (index > -1)
            {
                RemoveAt(index);
                index = FindIndex(s => s.Session == session);
            }
        }

        public void Remove(Predicate<SessionEdit> predicate)
        {
            SessionEditList sessions = FindAll(predicate);
            for(int i =0; i < sessions.Count; i++)
            {
                Remove(sessions[i].Session);
            }
        }

        public void RemoveOld()
        {
            Remove(s => s.Minuts > 15);
        }

        public SessionEdit Get(string session)
        {
            if (RemovingOld)
                RemoveOld();
            return Find(s => s.Session == session);
        }

        public SessionEdit Add(bool allowEdidConnection = false)
        {
            SessionEdit sessions = new SessionEdit(this);
            sessions.AllowEditConnection = allowEdidConnection;
            Add(sessions);
            return Get(sessions.Session);
        }

        public bool Contains(string session, bool checkAllowEditConnection = true)
        {
            if (RemovingOld)
                RemoveOld();
            List<SessionEdit> sessions = GetThis();
            if(checkAllowEditConnection)
            {
                return sessions.Any(s => s.Session == session && s.AllowEditConnection);
            }
            else
            {
                return sessions.Any(s => s.Session == session);
            }
        }

        public bool ContainsTokenAutotification(string session) => Contains(session, false);

        bool removingOld = true;

        public bool RemovingOld
        {
            get => removingOld;
            set => removingOld = value;
        }

    }
}
