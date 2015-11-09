using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAPWSL;
using IAPWSL.SubstanceProperties;
using System;

namespace IAPWS_Tests
{
    [TestClass]
    public class Region5Tests
    {
        [TestMethod]
        public void Region5_Test()
        {
            //Arrange
            double temperature1 = 1500; //K
            double pressure1 = 0.5; //MPa

            double temperature2 = 1500; //K
            double pressure2 = 30; //MPa

            double temperature3 = 2000; //K
            double pressure3 = 30; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;

            //Act
            substance1 = new Substance(temperature1, pressure1);
            substance2 = new Substance(temperature2, pressure2);
            substance3 = new Substance(temperature3, pressure3);

            //Assert
            Assert.AreEqual(0.138455090 * Math.Pow(10, 1), (double)substance1.SpecificVolume, 0.0000001,
                "Substance1: Substance has wrong specific volume");
            Assert.AreEqual(0.521976855 * Math.Pow(10, 4), (double)substance1.SpecificEnthalpy.Value, 0.00001,
                "Substance1: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.452749310 * Math.Pow(10, 4), (double)substance1.SpecificInternalEnergy, 0.00001,
                "Substance1: Substance has wrong specific internal energy");
            Assert.AreEqual(0.965408875 * Math.Pow(10,1), (double)substance1.SpecificEntropy.Value, 0.00000001,
                "Substance1: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.261609445 * Math.Pow(10, 1), (double)substance1.SpecificIsobaricHeatCapacity, 0.0000001,
                "Substance1: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.917068690 * Math.Pow(10, 3), (double)substance1.SpeedOfSound, 0.00001,
                "Substance1: Substance has wrong specific speed of sound");
            Assert.AreEqual(2.153, (double)substance1.SpecificIsochoricHeatCapacity, 0.001,
                "Substance1: Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.230761299 * Math.Pow(10, -1), (double)substance2.SpecificVolume, 0.00000001,
                "Substance2: Substance has wrong specific volume");
            Assert.AreEqual(0.516723514 * Math.Pow(10, 4), (double)substance2.SpecificEnthalpy.Value, 0.00001,
                "Substance2: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.447495124 * Math.Pow(10, 4), (double)substance2.SpecificInternalEnergy, 0.00001,
                "Substance2: Substance has wrong specific internal energy");
            Assert.AreEqual(0.772970133 * Math.Pow(10, 1), (double)substance2.SpecificEntropy.Value, 0.0000001,
                "Substance2: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.272724317 * Math.Pow(10, 1), (double)substance2.SpecificIsobaricHeatCapacity, 0.0000001,
                "Substance2: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.928548002 * Math.Pow(10, 3), (double)substance2.SpeedOfSound, 0.00001,
                "Substance2: Substance has wrong specific speed of sound");

            Assert.AreEqual(0.311385219 * Math.Pow(10, -1), (double)substance3.SpecificVolume, 0.00000001,
                "Substance3: Substance has wrong specific volume");
            Assert.AreEqual(0.657122604 * Math.Pow(10, 4), (double)substance3.SpecificEnthalpy.Value, 0.00001,
                "Substance3: Substance has wrong specific enthalpy");
            Assert.AreEqual(0.563707038 * Math.Pow(10, 4), (double)substance3.SpecificInternalEnergy, 0.00001,
                "Substance3: Substance has wrong specific internal energy");
            Assert.AreEqual(0.853640523 * Math.Pow(10, 1), (double)substance3.SpecificEntropy.Value, 0.00000001,
                "Substance3: Substance has wrong specific specific entropy");
            Assert.AreEqual(0.288569882 * Math.Pow(10, 1), (double)substance3.SpecificIsobaricHeatCapacity, 0.0000001,
                "Substance3: Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.106736948 * Math.Pow(10, 4), (double)substance3.SpeedOfSound, 0.00001,
                "Substance3: Substance has wrong specific speed of sound");
        }
    }
}
