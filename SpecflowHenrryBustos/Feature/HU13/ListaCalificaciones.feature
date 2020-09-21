Feature: ListaCalificaciones
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 01
	Given el docente desea que los clientes califiquen su desempeño laboral
	When el usuario inicie sesión en la aplicación web y vaya a la opción “Mi perfil”
	Then se mostrará una interfaz donde se seleccionará la opción “calificación”
	And en donde se podrá visualizar los comentarios hechos por los clientes respecto al desempeño del usuario