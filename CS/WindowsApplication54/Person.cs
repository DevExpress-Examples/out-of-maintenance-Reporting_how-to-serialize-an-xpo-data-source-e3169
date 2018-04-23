using System;
using System.Text;
using System.Collections.Generic;
using DevExpress.Xpo;
// ...

namespace WindowsApplication54 {
    public class Person : XPObject {
        public static Person Create(Session session, string name) {
            Person person = new Person(session);
            person.Name = name;
            return person;
        }
        string name;

        public Person(Session session)
            : base(session) {
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
    }

}
