Feature: CancelarMembresia
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 05
	Given Un docente ya no quiere contar con la membresía
	When el docente iniciará sesión en la web, entonces se dirigirá a su perfil de docente
	Then se le mostrará el status de su membresía con la opción de "Cancelar Membresía"