Feature: EliminarTarjeta
	COMO padre de familia 
	QUIERO poder eliminar una tarjeta
	PARA tener actualizado mis metodos de pago

@mytag
Scenario: Mostrar ventana de confirmación
	Given el padre ha iniciado sesión correctamente y se encuentra en la sesión “Tarjetas”
	When seleccione la opción “eliminar” de una tarjeta registrada
	Then se mostrara una ventana de confirmación con las opciónes de aceptar y rechazar la acción.
@mytag
Scenario: Confirmar accion
	Given el padre se encuentra en la ventana de confirmación para eliminar una tarjeta 
	When seleccione la opción “aceptar”
	Then la tarjeta será eliminada del sistema y se mostrara un mensaje de “Método de pago eliminado satisfactoriamente”.
@mytag
Scenario: Cancelar accion
	Given el padre se encuentra en la ventana de confirmación para eliminar una tarjeta 
	When seleccione la opción “cancelar” 
	Then la tarjeta no será eliminada del sistema.