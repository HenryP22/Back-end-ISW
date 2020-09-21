Feature: RegistrarTutoría
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 01
	Given el docente desea registrar la tutoría a brindar
	When el docente iniciara sesión en la web y se dirigirá a la opción“Registrar Tutoría”
	Then se le mostrará una interfaz donde deberá escoger el nivel académico
	And además tendrá que ingresar los datos de la tutoría (Fecha, costo, horas, tema)