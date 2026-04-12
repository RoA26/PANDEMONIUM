tareas = []

while True:
    accion = input("(a)gregar, (v)er, (e)liminar, (s)alir: ")
    if accion == "a":
        tarea = input("Nueva tarea: ")
        tareas.append(tarea)
        print(f"Agregada. tienes {len(tareas)} tarea(s). ")
    elif accion == "v":
        if len (tareas) == 0:
            print("No tienes tareas.")
        else:
            for i, t in enumerate(tareas):
                print(f"{i+1}. {t}")
    elif accion == "e":
        print(f"Indique el numero de la tarea que desea eliminar")
        numero = int(input("Cual? "))
        tareas.pop(numero - 1)
    
    elif accion == "s":
        break