Feature: EliminarTutoría
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 04
	Given el Docente desea eliminar la tutoría publicada en la aplicación web
	When el docente iniciara sesión en la web y se dirigirá a la opción “Mis tutorías”
	Then se mostrará un interfaz  donde el docente escogerá la tutoría publicada y finalmente seleccionará la opción ”eliminar”