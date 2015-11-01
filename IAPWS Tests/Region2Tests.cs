using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAPWSL;
using IAPWSL.SubstanceProperties;
using Moq;

namespace IAPWS_Tests
{
    /*
    Test carrys out for 3 different substances.
    It checks property values of substances.
    */
    [TestClass]
    public class Region2Tests
    {
        [TestMethod]
        public void Region2Test()
        {
            //Arrange
            double temperature1 = 300; //K
            double pressure1 = 0.0035; //MPa

            double temperature2 = 700; //K
            double pressure2 = 0.0035; //MPa

            double temperature3 = 700; //K
            double pressure3 = 30; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(temperature1, pressure1);
            substance2 = new Substance(temperature2, pressure2);
            substance3 = new Substance(temperature3, pressure3);
            //Assert
            Assert.AreEqual(0.394913866 * Math.Pow(10, 2), (double)substance1.SpecificVolume, 0.0000001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(0.254991145 * Math.Pow(10, 4), (double)substance1.SpecificEnthalpy.Value, 0.0001,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.241169160 * Math.Pow(10, 4), (double)substance1.SpecificInternalEnergy, 0.0001,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(8.52238967, (double)substance1.SpecificEntropy.Value, 0.0000001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.191300162 * Math.Pow(10, 1), (double)substance1.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.427920172 * Math.Pow(10, 3), (double)substance1.SpeedOfSound, 0.001,
                "Substance1: Substance has wrong specific speed of sound");
            Assert.AreEqual(1.441, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.923015898 * Math.Pow(10, 2), (double)substance2.SpecificVolume, 0.0000001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(0.333568375 * Math.Pow(10, 4), (double)substance2.SpecificEnthalpy.Value, 0.0001,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.301262819 * Math.Pow(10, 4), (double)substance2.SpecificInternalEnergy, 0.0001,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(0.101749996 * Math.Pow(10, 2), (double)substance2.SpecificEntropy.Value, 0.0000001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.208141274 * Math.Pow(10, 1), (double)substance2.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.644289068 * Math.Pow(10, 3), (double)substance2.SpeedOfSound, 0.001,
                "Substance2: Substance has wrong specific speed of sound");
            Assert.AreEqual(1.620, (double)substance2.SpecificIsochoricHeatCapacity, 0.001,
                "Substance2: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.542946619 * Math.Pow(10, -2), (double)substance3.SpecificVolume, 0.0000001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(0.263149474 * Math.Pow(10, 4), (double)substance3.SpecificEnthalpy.Value, 0.0001,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.246861076 * Math.Pow(10, 4), (double)substance3.SpecificInternalEnergy, 0.0001,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(0.517540298 * Math.Pow(10, 1), (double)substance3.SpecificEntropy.Value, 0.0000001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.103505092 * Math.Pow(10, 2), (double)substance3.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.480386523 * Math.Pow(10, 3), (double)substance3.SpeedOfSound, 0.001,
                "Substance3: Substance has wrong specific speed of sound");
            Assert.AreEqual(2.976, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance3: Substance has wrong specific isochoric heat capacity");
        }

    }
}
