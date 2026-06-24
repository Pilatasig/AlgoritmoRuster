const API_CARGOS = window.location.origin + '/api/cargos';
const API_DEPARTAMENTOS = window.location.origin + '/api/departamentos';
let instanciaModal;
let cacheCargos = []; // Almacena temporalmente los cargos para filtrado rápido

document.addEventListener("DOMContentLoaded", () => {
    // SINCRO JSP: Se vincula usando el ID exacto del modal del JSP
    instanciaModal = new bootstrap.Modal(document.getElementById('modalEditar'));
    
    cargarDepartamentosEnCombos();
    cargarCargos();

    // Escucha el envío del formulario de registro (CREAR)
    document.getElementById('formCargo').addEventListener('submit', async (e) => {
        e.preventDefault();
        
        // SINCRO JSP: Capturamos los datos basándonos en las nuevas exigencias (nombre = nemónico)
        const nombre = document.getElementById('nombreCargo').value.toUpperCase().trim();
        const descripcion = document.getElementById('descripcionCargo').value.trim();
        const codigoDepartamento = document.getElementById('comboDepartamento').value;

        // Armamos el payload SIN enviar el atributo 'codigo' (lo calcula el servicio)
        const payload = {
            nombre: nombre, // Nemónico de 3 letras (Ej: GER)
            descripcion: descripcion,
            departamento: {
                codigo: codigoDepartamento
            }
        };

        const res = await fetch(API_CARGOS, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (res.ok) {
            mostrarAlerta("Cargo registrado con éxito.", "success");
            document.getElementById('formCargo').reset();
            cargarCargos(); // Refresca para ver el nuevo "CARXXX" asignado
        } else {
            mostrarAlerta(await res.text(), "danger");
        }
    });

    // Escucha el cambio en el selector de filtrado superior
    document.getElementById('filtroDepartamento').addEventListener('change', filtrarTablaCargos);
});

// POBLAR SELECTORES DE DEPARTAMENTOS
async function cargarDepartamentosEnCombos() {
    try {
        const res = await fetch(API_DEPARTAMENTOS);
        const departamentos = await res.json();
        
        const comboAlta = document.getElementById('comboDepartamento');
        const comboEdicion = document.getElementById('editComboDepartamento');
        const filtroDepar = document.getElementById('filtroDepartamento');

        departamentos.forEach(d => {
            const codLimpio = d.codigo.trim();
            const descLimpia = d.descripcion.trim();
            const opcionHtml = `<option value="${codLimpio}">${codLimpio} - ${descLimpia}</option>`;
            
            comboAlta.innerHTML += opcionHtml;
            comboEdicion.innerHTML += opcionHtml;
            filtroDepar.innerHTML += opcionHtml;
        });
    } catch (error) {
        console.error("Error al poblar selectores de departamentos:", error);
    }
}

// OBTENER TODOS LOS CARGOS
async function cargarCargos() {
    try {
        const res = await fetch(API_CARGOS);
        cacheCargos = await res.json(); // Guardamos los datos en la caché local
        filtrarTablaCargos(); // Renderizamos aplicando el filtro activo
    } catch (error) {
        console.error("Error al recuperar los cargos:", error);
    }
}

// FILTRADO DINÁMICO Y RENDERIZADO DE TABLA
function filtrarTablaCargos() {
    const filtroSeleccionado = document.getElementById('filtroDepartamento').value;
    const cuerpoTabla = document.getElementById('tablaCuerpo');
    cuerpoTabla.innerHTML = "";

    // Filtramos el array local según el criterio seleccionado
    const cargosFiltrados = cacheCargos.filter(c => {
        if (filtroSeleccionado === "TODOS") return true;
        return c.departamento && c.departamento.codigo.trim() === filtroSeleccionado;
    });

    if (cargosFiltrados.length === 0) {
        // SINCRO JSP: Se ajusta el colspan a 5 columnas por la nueva estructura
        cuerpoTabla.innerHTML = `<tr><td colspan="5" class="text-center text-muted py-3">No existen cargos para el criterio seleccionado.</td></tr>`;
        return;
    }

    const tieneP22 = typeof PERMISOS !== 'undefined' && PERMISOS.includes('P22');
    const tieneP24 = typeof PERMISOS !== 'undefined' && PERMISOS.includes('P24');

    cargosFiltrados.forEach(c => {
        const codCargo = c.codigo ? c.codigo.trim() : "";
        const nomCargo = c.nombre ? c.nombre.trim() : "";
        const descCargo = c.descripcion ? c.descripcion.trim() : "";
        const nombreDepar = c.departamento ? c.departamento.descripcion.trim() : 'No asignado';
        const codigoDepar = c.departamento ? c.departamento.codigo.trim() : '';
        let acciones = '<div class="d-flex justify-content-center gap-1">';
        if (tieneP22) acciones += `<button class="btn btn-sm btn-warning fw-semibold" onclick="abrirModalEditar('${codCargo}', '${nomCargo}', '${descCargo}', '${codigoDepar}')"><i class="bi bi-pencil-fill"></i></button> `;
        if (tieneP24) acciones += `<button class="btn btn-sm btn-danger fw-semibold" onclick="ejecutarEliminacion('${codCargo}')"><i class="bi bi-trash-fill"></i></button>`;
        acciones += '</div>';

        cuerpoTabla.innerHTML += `
            <tr>
                <td class="fw-bold text-secondary">${codCargo}</td>
                <td class="fw-bold text-primary">${nomCargo}</td>
                <td>${descCargo}</td>
                <td><span class="badge bg-secondary">${codigoDepar}</span> ${nombreDepar}</td>
                <td class="text-center">${acciones}</td>
            </tr>
        `;
    });
}

// PRE-EDITAR (Cargar datos en Modal)
function abrirModalEditar(codigo, nombre, descripcion, codigoDepartamento) {
    // SINCRO JSP: Cargamos los datos usando los nuevos IDs específicos de edición
    document.getElementById('editCodigoCargo').value = codigo;
    document.getElementById('editNombreCargo').value = nombre;
    document.getElementById('editDescripcionCargo').value = descripcion;
    document.getElementById('editComboDepartamento').value = codigoDepartamento;
    
    instanciaModal.show();
}

// GUARDAR EDICIÓN (MODIFICAR)
async function guardarEdicion() {
    const codigo = document.getElementById('editCodigoCargo').value;
    const nombre = document.getElementById('editNombreCargo').value.toUpperCase().trim();
    const descripcion = document.getElementById('editDescripcionCargo').value.trim();
    const codigoDepartamento = document.getElementById('editComboDepartamento').value;

    // SINCRO BACKEND: Estructuramos el payload mapeado con la clase Cargo.java
    const payload = {
        codigo: codigo,
        nombre: nombre,
        descripcion: descripcion,
        departamento: {
            codigo: codigoDepartamento
        }
    };

    const res = await fetch(`${API_CARGOS}/${codigo}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
    });

    if (res.ok) {
        instanciaModal.hide();
        mostrarAlerta("Cargo actualizado de manera correcta.", "success");
        cargarCargos(); // Refresca los datos en la vista
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

// ELIMINAR REGISTRO
async function ejecutarEliminacion(codigo) {
    if (!confirm(`¿Está seguro de eliminar el cargo [${codigo}]?`)) return;

    const res = await fetch(`${API_CARGOS}/${codigo}`, { method: 'DELETE' });
    if (res.ok) {
        mostrarAlerta("Cargo removido de la base de datos de manera correcta.", "success");
        cargarCargos();
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

// NOTIFICACIONES GENERALES
function mostrarAlerta(mensaje, tipo) {
    const box = document.getElementById('alertGlobal');
    box.className = `alert alert-${tipo}`;
    box.textContent = mensaje;
    box.classList.remove('d-none');
    setTimeout(() => box.classList.add('d-none'), 4000);
}