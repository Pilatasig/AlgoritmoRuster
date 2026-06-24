const API_URL = window.location.origin + '/api/departamentos';
let instanciaModal;

document.addEventListener("DOMContentLoaded", () => {
    // Vincula la ventana flotante de Bootstrap a una variable de JS usando el ID nuevo
    instanciaModal = new bootstrap.Modal(document.getElementById('modalEditar'));
    
    cargarDepartamentos();

    // Escucha cuando el usuario envía el formulario de registro
    document.getElementById('formDepar').addEventListener('submit', async (e) => {
        e.preventDefault(); // Evita que la página parpadee o se recargue
        
        // REESTRUCTURADO: Ya no enviamos un 'codigo' manual. El backend genera el DEPXXX.
        const nombre = document.getElementById('nombreDepar').value.toUpperCase().trim();
        const descripcion = document.getElementById('descriDepar').value.trim();

        // Envía los datos al servidor en formato JSON (CREAR)
        const res = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ nombre, descripcion })
        });

        if (res.ok) {
            mostrarAlerta("Departamento creado con éxito", "success");
            document.getElementById('formDepar').reset(); // Limpia las cajas de texto
            cargarDepartamentos(); // Refresca la tabla para ver el nuevo DEPXXX asignado
        } else {
            mostrarAlerta(await res.text(), "danger"); // Muestra el error del servidor
        }
    });
});

// 2. FUNCIÓN LISTAR: Limpia la tabla y la vuelve a dibujar con datos frescos de MySQL/MariaDB
async function cargarDepartamentos() {
    try {
        const res = await fetch(API_URL);
        const departamentos = await res.json();
        const cuerpoTabla = document.getElementById('tablaCuerpo');
        cuerpoTabla.innerHTML = ""; 

        if (departamentos.length === 0) {
            cuerpoTabla.innerHTML = `<tr><td colspan="4" class="text-center text-muted py-3">No existen departamentos registrados.</td></tr>`;
            return;
        }

        const tieneP12 = typeof PERMISOS !== 'undefined' && PERMISOS.includes('P12');
        const tieneP14 = typeof PERMISOS !== 'undefined' && PERMISOS.includes('P14');

        departamentos.forEach(d => {
            const codPK = d.codigo ? d.codigo.trim() : ""; 
            const nemonico = d.nombre ? d.nombre.trim() : "";
            const descripcion = d.descripcion ? d.descripcion.trim() : "";
            let acciones = '<div class="d-flex justify-content-center gap-1">';
            if (tieneP12) acciones += `<button class="btn btn-sm btn-warning fw-semibold" onclick="abrirModalEditar('${codPK}', '${nemonico}', '${descripcion}')"><i class="bi bi-pencil-fill"></i></button> `;
            if (tieneP14) acciones += `<button class="btn btn-sm btn-danger fw-semibold" onclick="ejecutarEliminacion('${codPK}')"><i class="bi bi-trash-fill"></i></button>`;
            acciones += '</div>';

            cuerpoTabla.innerHTML += `
                <tr>
                    <td class="fw-bold text-secondary">${codPK}</td>
                    <td class="fw-bold text-primary">${nemonico}</td>
                    <td>${descripcion}</td>
                    <td class="text-center">${acciones}</td>
                </tr>
            `;
        });
    } catch (error) {
        console.error("Error al cargar la tabla:", error);
    }
}

// 3. FUNCIÓN PRE-EDITAR: Abre la ventana modal cargando el estado actual de la fila
function abrirModalEditar(codigoDepar, nombreDepar, descriDepar) {
    document.getElementById('editCodigoDepar').value = codigoDepar.trim();
    document.getElementById('editNombreDepar').value = nombreDepar.trim();
    document.getElementById('editDescriDepar').value = descriDepar.trim();
    
    instanciaModal.show(); // Hace visible el cuadro flotante
}

// 4. FUNCIÓN GUARDAR EDICIÓN: Envía la actualización dual al controlador (Map de Java)
async function guardarEdicion() {
    const codigoPK = document.getElementById('editCodigoDepar').value.trim().toUpperCase();
    const nuevoNemonico = document.getElementById('editNombreDepar').value.toUpperCase().trim();
    const nuevaDescripcion = document.getElementById('editDescriDepar').value.trim();

    // Ruta final configurada en el controlador: /api/departamentos/DEPXXX
    const urlDestino = `${API_URL}/${codigoPK}`;

    // ADAPTADO: Las llaves del JSON coinciden con el payload.get("...") del DepartamentoController
    const res = await fetch(urlDestino, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ 
            nombre: nuevoNemonico, 
            descripcion: nuevaDescripcion 
        })
    });

    if (res.ok) {
        instanciaModal.hide(); // Oculta la ventana flotante
        mostrarAlerta("Departamento actualizado correctamente", "success");
        cargarDepartamentos(); // Refresca la tabla
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

// 5. FUNCIÓN ELIMINAR: Pide confirmación y ejecuta el borrado físico usando la PK autogenerada
async function ejecutarEliminacion(codigoPK) {
    const codigoLimpio = codigoPK.trim().toUpperCase();
    
    if (!confirm(`¿Está seguro de eliminar el departamento [${codigoLimpio}]?\n\n¡ADVERTENCIA! Si este departamento posee cargos asociados, el sistema bloqueará la operación por integridad referencial.`)) {
        return; // Si el usuario cancela, rompe el flujo
    }

    const urlDestino = `${API_URL}/${codigoLimpio}`;

    const res = await fetch(urlDestino, { 
        method: 'DELETE' 
    });
    
    if (res.ok) {
        mostrarAlerta("Departamento eliminado de la base de datos", "success");
        cargarDepartamentos(); // Refresca la tabla
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

// 6. FUNCIÓN AUXILIAR: Controla los componentes gráficos de notificación temporal
function mostrarAlerta(mensaje, tipo) {
    const box = document.getElementById('alertGlobal');
    box.className = `alert alert-${tipo}`; // Cambia dinámicamente el estilo visual de Bootstrap
    box.textContent = mensaje;
    box.classList.remove('d-none'); // Quita la propiedad oculta
    
    setTimeout(() => {
        box.classList.add('d-none');
    }, 4000);
}