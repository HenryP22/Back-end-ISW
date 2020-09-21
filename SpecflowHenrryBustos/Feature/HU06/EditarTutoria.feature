Feature: EditarTutoría
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 03
	Given el docente desea editar información errónea respecto al servicio de tutoría que quiere brindar
	When este se diriga a la opción "anterior"
	Then se le mostrará la interfaz de registro con sus datos anteriores