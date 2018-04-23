using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.UI;
// ...

namespace WindowsApplication54 {
    public partial class Form1 : Form {
        static Form1() {
            // The following code is required to support serialization of multiple custom objects.
            TypeDescriptor.AddAttributes(typeof(XPCollection), new ReportAssociatedComponentAttribute());

            // The following code is required to serialize custom objects.
            ReportExtension.RegisterExtensionGlobal(new ReportExtension());
            ReportDesignExtension.RegisterExtension(new DesignExtension(), ExtensionName);

            string fileName = 
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\person.mdb";
            if (!File.Exists(fileName)) {
                UnitOfWork session = CreateSessionByName("person.mdb");
                if (new XPCollection<Person>(session).Count < 6) {
                    Person.Create(session, "Name1");
                    Person.Create(session, "Name2");
                    Person.Create(session, "Name3");
                    Person.Create(session, "Name4");
                    Person.Create(session, "Name5");
                    Person.Create(session, "Name6");
                    session.CommitChanges();
                }
            }
        }
        static UnitOfWork CreateSessionByName(string name) {
            string connectionString = AccessConnectionProvider.GetConnectionString(name);
            return CreateSession(connectionString);
        }
        static XPCollection<Person> CreateDataSource(UnitOfWork session) {
            return new XPCollection<Person>(session);
        }
        public static UnitOfWork CreateSession(string connectionString) {
            UnitOfWork result = new UnitOfWork();
            result.ConnectionString = connectionString;
            return result;
        }

        private const string ExtensionName = "Custom";

        public Form1() {
            InitializeComponent();
        }
        private void createReportWhithDataSourceButton_Click(object sender, EventArgs e) {
            using (UnitOfWork session = CreateSessionByName("person.mdb")) {
                XtraReport report = new XtraReport();
                ReportDesignExtension.AssociateReportWithExtension(report, ExtensionName);
                report.DataSource = CreateDataSource(session);
                report.ShowDesignerDialog();
            }
        }
        private void createEmptyReportButton_Click(object sender, EventArgs e) {
            new XtraReport().ShowDesignerDialog();
        }
        class ReportExtension : ReportStorageExtension {
            public override void SetData(XtraReport report, Stream stream) {
                report.SaveLayoutToXml(stream);
            }
            public override void SetData(XtraReport report, string url) {
                report.SaveLayoutToXml(url);
            }
        }
        class DesignExtension : ReportDesignExtension {
            protected override bool CanSerialize(object data) {
                return data is XPCollection<Person>;
            }
            protected override string SerializeData(object data, XtraReport report) {
                XPCollection<Person> collection = data as XPCollection<Person>;
                if (collection != null)
                    return collection.Session.ConnectionString;
                return base.SerializeData(data, report);
            }
            protected override bool CanDeserialize(string value, string typeName) {
                return typeof(XPCollection<Person>).FullName == typeName;
            }
            protected override object DeserializeData(string value, 
                string typeName, XtraReport report) {
                if (typeof(XPCollection<Person>).FullName == typeName) {
                    XPCollection<Person> result = new XPCollection<Person>();
                    result.Session = Form1.CreateSession(value);
                    return result;
                }
                return base.DeserializeData(value, typeName, report);
            }
        }
    }
}