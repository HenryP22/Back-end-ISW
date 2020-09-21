Feature: MetodosPago
	COMO padre de familia 
	QUIERO poder gestionar mis métodos de pago 
	PARA poder realizar pagos fututos de las tutorías de mis hijos.

@mytag
Scenario: Visualizar metodos de pago
	Given el usuario padre ha iniciado sesión correctamente
	And se encuentra en la sección “Mi perfil”
	And the second number is 70
	When seleccione la opción “Tarjetas”
	Then podrá visualizar las tarjetas que tiene registradas, donde cada ítem tendrá la opción de ser eliminado

@mytag
Scenario: Registrar tarjeta
	Given el usuario padre ha iniciado sesión correctamente
	And se encuentra en la sección “Tarjetas” 
	When seleccione la opción “Agregar tarjeta” 
	Then se mostrara un formulario para el registro de una nueva tarjeta

@mytag
Scenario: Datos mal ingresados
	Given el ususario padre se encuentra en el formulario de registro de nueva tarjeta
	When se ingrese información incorrecta y se envié el formulario 
	Then el sistema mostrara el mensaje “los datos no son correctos”


@mytag
Scenario: Eliminar tarjeta
	Given el usuario padre ha iniciado sesión correctamente
	And se encuentra en la sesión “Tarjetas”
	When seleccione la opción “eliminar” de una tarjeta registrada 
	Then se mostrara una ventana de confirmación de esa acción.
