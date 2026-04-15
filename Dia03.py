inventario = {"machete": 1, "Frias": 5, "dineral": 100 }

def mostrar_inventario(inv):
    print("/n--- Inventario ---")
    for item, cantidad in inv.items():
        print(f"    {item}: {cantidad}")

def agregar_item(inv, item, cantidad):
    if item in inv:
        inv[item] += cantidad
    else:
        inv[item] = cantidad
    return inv

def eliminar_item(inv, item, cantidad):
    if item in inv:
        inv[item] -= cantidad
        if inv[item] == 0:
           del inv[item]
    return inv

        


mostrar_inventario(inventario)
inventario = agregar_item(inventario, "escudo", 1)
inventario = agregar_item(inventario, "frias", 3)
inventario = eliminar_item(inventario, "machete", 1)
mostrar_inventario(inventario) 