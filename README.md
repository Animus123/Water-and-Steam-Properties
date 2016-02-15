#Water and Steam Properties Library

IAPWS stands for Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam.
This library could be used to evaluate steam and water properties.
The library is based on "Revised Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of
Water and Steam".

##How to use

In order to use the library you should create an instance of the *Substance* class and pass temperature and pressure as arguments:

*Substance s = new Substance(550, 13); // 550 - temperature in K(Kelvin), 13 - pressure in MPa(Megapascals)*

Also, there are another constructor overloads (see IAPWS Example project). For example we can pass to the constructor pressure and entropy values:

*// 2 - pressure in MPa(Megapascals), 6 - entropy in kJ/(kg*K)*

*s = new Substance(new Pressure(2), new Entropy(6));*

*//The same but in more detail:*

*s = new Substance(new Pressure(2, Pressure.Measure.MPa),*
					*new Entropy(6, Entropy.Measure.kJ_kgK));*
					
Once you get an object you can use its properties in your calculations.
All of the properties are listed below:

- Specific Volume  
- Specific Internal Energy  
- Specific Entropy  
- Specific Enthalpy  
- Specific Isobaric Heat Capacity  
- Specific Isochoric Heat Capacity  
- Speed of Sound  
- Temperature  
- Pressure  

