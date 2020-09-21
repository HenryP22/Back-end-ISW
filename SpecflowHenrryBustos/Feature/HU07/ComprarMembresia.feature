Feature: ComprarMembresia
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 03
	Given un docente quiere realizar la compra de una membresía por medio de la página web
	When El docente iniciará sesión a la web, luego seleccionará la opción “Obtener membresía”
	Then se mostrará una interfaz donde se le pedirá al docente que seleccione la tarjeta anteriormente registrada
	And luego de ello colocara el cvc, asimismo escogerá el plan de membresía que más le convenga 
	And finalmente seleccionará la opción “comprar” .