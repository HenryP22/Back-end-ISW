Feature: MOstrarInformes
	COMO padre de familia 
	QUIERO poder revisar los informes de mi hijo 
	PARA poder conocer detalladamente su desempeño académico

@mytag
Scenario: Informe no disponible
	Given el padre de familia se encuentra en la sección “Mis clases”
	When se dirija a los detalles de una clase y no haya información
	Then no podrá descargar el informe del alumno y se mostrara el mensaje “informe no disponible”
@mytag
Scenario: Informe disponible
	Given el padre de familia se encuentra en la sección “Mis clases”
	When se dirija a los detalles de la clase y el informe ha sido subido 
	Then podrá visualizar el nombre del informe y un botón para descargarlo
@mytag
Scenario: Notificar correccion de informe
	Given Dado que el padre de familia se encuentra en la sección de “Mis clases”
	And y el informe ya está disponible 
	When el padre determine que la información no es correcta y seleccione la opción de notificar docente 
	Then se realizara él envió de una notificación al docente solicitando la corrección del informe.