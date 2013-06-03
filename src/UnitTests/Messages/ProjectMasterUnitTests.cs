﻿using AmplaTools.ProjectCreate.Helper;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Messages
{
    public class ProjectMasterUnitTests : TestFixture
    {
        private const string exampleResourcePath = "AmplaTools.ProjectCreate.Resources.Messages.ProjectMaster.Example.xml";


        [Test]
        public void DefaultHierarchy()
        {
            ProjectMaster master = new ProjectMaster();
            Assert.That(master, Is.Not.Null);
            Assert.That(master.Hierarchy, Is.Not.Null);
            Assert.That(master.Hierarchy.href, Is.Not.Null);
        }

        [Test]
        public void ContainsNamespace()
        {
            ProjectMaster master = new ProjectMaster {Hierarchy = new ProjectHierarchy {href = "Hierarchy.xml"}};

            Assert.That(ProjectMaster.Namespace, Is.StringStarting("http://"));
            Assert.That(ProjectMaster.Namespace, Is.StringContaining("github"));

            string xml = SerializationHelper.SerializeToString(master);
            Assert.That(xml, Is.StringContaining(ProjectMaster.Namespace));
        }

        [Test]
        public void Roundtrip()
        {
            ProjectMaster master = new ProjectMaster
                {
                    Hierarchy = new ProjectHierarchy {href = "Customer.Hierarchy.xml"}
                };

            string xml = SerializationHelper.SerializeToString(master);
            ProjectMaster result = SerializationHelper.DeserializeFromString<ProjectMaster>(xml);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Hierarchy, Is.Not.Null);
            Assert.That(result.Hierarchy.href, Is.EqualTo(master.Hierarchy.href));
        }

        [Test]
        public void RoundTripFromString()
        {
            string xml = AssemblyResources.GetTextFile(typeof(ProjectMasterUnitTests).Assembly, exampleResourcePath);
            ProjectMaster projectMaster = SerializationHelper.DeserializeFromString<ProjectMaster>(xml);

            string roundTrip = SerializationHelper.SerializeToString(projectMaster);

            Assert.That(roundTrip, Is.EqualTo(xml)); 
        }

    }
}
