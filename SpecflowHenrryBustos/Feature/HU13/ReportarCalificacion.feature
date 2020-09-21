Feature: ReportarCalificacion
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 03
	Given el usuario desea reportar una calificación negativa errónea respecto a su desempeño laboral
	And the second number is 70
	When el usuario inicie sesión en la aplicación web y vaya a la opción “mi perfil”
	Then se mostrará una interfaz donde se seleccionará la opción “calificación”, en donde se podrá visualizar los comentarios
	And luego de ello seleccionará el comentario erróneo registrado y finalmente seleccionará la opción “reportar”