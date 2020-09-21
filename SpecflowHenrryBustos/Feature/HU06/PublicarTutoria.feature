Feature: PublicarTutoría
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 02
	Given el docente desea publicar la tutoría a brindar
	When ya haya ingresado todos los datos de la tutoría, este se dirigirá a la opción "Siguiente"
	Then se le mostrará una interfaz con los datos de la tutoría para que pueda revisar si están correctos 
	And si es así seleccionará la opción "Publicar"