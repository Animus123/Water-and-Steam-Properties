using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAPWSL;
using Moq;

/*I MADE TEST ONLY FOR BASIC EQUATION FOR REGION 1*/
namespace IAPWS_Tests
{
    /*
    Test carrys out for 3 different substances.
    It checks property values of substances.
    */
    [TestClass]
    public class Region1Tests
    {
        [TestMethod]
        public void Region1Test()
        {
            //Arrange
            double temperature1 = 300; //K
            double pressure1 = 3; //MPa

            double temperature2 = 300; //K
            double pressure2 = 80; //MPa

            double temperature3 = 500; //K
            double pressure3 = 3; //MPa

            Substance substance1;
            Substance substance2;
            Substance substance3;
            //Act
            substance1 = new Substance(temperature1, pressure1);
            substance2 = new Substance(temperature2, pressure2);
            substance3 = new Substance(temperature3, pressure3);
            //Assert
            Assert.AreEqual(0.100215168 * Math.Pow(10, -2), (double)substance1.SpecificVolume, 0.0000001,
                "Substance has wrong specific volume");
            Assert.AreEqual(0.115331273 * Math.Pow(10, 3), (double)substance1.SpecificEnthalpy, 0.0001,
                "Substance has wrong specific enthalpy");
            Assert.AreEqual(0.112324818 * Math.Pow(10, 3), (double)substance1.SpecificInternalEnergy, 0.0001,
                "Substance has wrong specific internal energy");
            Assert.AreEqual(0.392294792, (double)substance1.SpecificEntropy, 0.0000001,
                "Substance has wrong specific specific entropy");
            Assert.AreEqual(0.417301218 * Math.Pow(10, 1), (double)substance1.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.150773921 * Math.Pow(10, 4), (double)substance1.SpeedOfSound, 0.001,
                "Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(4.121, (double)substance1.SpecificIsochoricHeatCapacity, 0.01,
                "Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.971180894 * Math.Pow(10, -3), (double)substance2.SpecificVolume, 0.0000001,
                "Substance has wrong specific volume");
            Assert.AreEqual(0.184142828 * Math.Pow(10, 3), (double)substance2.SpecificEnthalpy, 0.0001,
                "Substance has wrong specific enthalpy");
            Assert.AreEqual(0.106448356 * Math.Pow(10, 3), (double)substance2.SpecificInternalEnergy, 0.0001,
                "Substance has wrong specific internal energy");
            Assert.AreEqual(0.368563852, (double)substance2.SpecificEntropy, 0.0000001,
                "Substance has wrong specific specific entropy");
            Assert.AreEqual(0.401008987 * Math.Pow(10, 1), (double)substance2.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.163469054 * Math.Pow(10, 4), (double)substance2.SpeedOfSound, 0.001,
                "Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.917, (double)substance2.SpecificIsochoricHeatCapacity, 0.01,
                "Substance has wrong specific isochoric heat capacity");

            Assert.AreEqual(0.120241800 * Math.Pow(10, -2), (double)substance3.SpecificVolume, 0.0000001,
                "Substance has wrong specific volume");
            Assert.AreEqual(0.975542239 * Math.Pow(10, 3), (double)substance3.SpecificEnthalpy, 0.0001,
                "Substance has wrong specific enthalpy");
            Assert.AreEqual(0.971934985 * Math.Pow(10, 3), (double)substance3.SpecificInternalEnergy, 0.0001,
                "Substance has wrong specific internal energy");
            Assert.AreEqual(0.258041912 * Math.Pow(10, 1), (double)substance3.SpecificEntropy, 0.0000001,
                "Substance has wrong specific specific entropy");
            Assert.AreEqual(0.465580682 * Math.Pow(10, 1), (double)substance3.SpecificIsobaricHeatCapacity, 0.000001,
                "Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(0.124071337 * Math.Pow(10, 4), (double)substance3.SpeedOfSound, 0.001,
                "Substance has wrong specific isobaric heat capacity");
            Assert.AreEqual(3.221, (double)substance3.SpecificIsochoricHeatCapacity, 0.01,
                "Substance has wrong specific isochoric heat capacity");
        }

        [TestMethod]
        public void Region1BackwardEquation_Tph_Test()
        {
            //Arrange

            //Act
            //Assert
        }


    }
}
