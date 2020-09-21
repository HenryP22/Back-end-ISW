Feature: FiltrarDocentes
	COMO padre de familia 
	QUIERO poder filtrar la lista de docentes 
	PARA una óptima búsqueda con respecto a mis requerimientos

@mytag
Scenario: Buscar por docente
	Given el usuario padre se encuentra en la sección “Mis clases”
	When ingrese el nombre del profesor en el formulario de búsqueda y presione en buscar
	Then se listaran los docentes que cumplan con el filtro

@mytag
Scenario: Buscar por curso
	Given el usuario padre  se encuentra en la sección “Mis clases”
	When ingrese el nombre del curso en el formulario de búsqueda y presione en buscar
	Then se listaran los docentes que enseñen el curso ingresado

@mytag
Scenario: Buscar por costo
	Given el usuario padre se encuentra en la sección “Mis clases”
	When ingrese el rango de un costo deseado en el formulario de búsqueda y seleccione la opción “Buscar” 
	Then se listaran solo los docentes que cobren esa cantidad
@mytag
Scenario: Buscar por tiempo
	Given el usuario padre se encuentra en la sección “Mis clases”
	When ingrese una cantidad de horas en el formulario de búsqueda y seleccione “Buscar”
	Then se mostraran los docentes que estén enseñando la cantidad de horas deseada