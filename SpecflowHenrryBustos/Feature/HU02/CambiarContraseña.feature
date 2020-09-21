Feature: CambiarContraseña
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 01
	Given quiero actualizar la contraseña
	When quiero introducir una nueva contraseña
	Then la aplicación me indica que la contraseña debe tener más de 8 caracteres
	And no debe contener especiales y esta no podrá ser la misma que la actual u otras anteriores.