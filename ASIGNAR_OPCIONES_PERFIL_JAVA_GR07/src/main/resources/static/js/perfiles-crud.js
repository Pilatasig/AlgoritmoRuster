const API_PERFILES = window.location.origin + '/api/perfiles';
let instanciaModal;
let cachePerfiles = [];

document.addEventListener("DOMContentLoaded", () => {
    instanciaModal = new bootstrap.Modal(document.getElementById('modalEditar'));

    cargarPerfiles();

    document.getElementById('formPerfil').addEventListener('submit', async (e) => {
        e.preventDefault();

        const nombre = document.getElementById('nombrePerfil').value.toUpperCase().trim();
        const descripcion = document.getElementById('descripcionPerfil').value.trim();

        const payload = {
            nombre: nombre,
            descripcion: descripcion
        };

        const res = await fetch(API_PERFILES, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (res.ok) {
            mostrarAlerta("Perfil registrado con éxito.", "success");
            document.getElementById('formPerfil').reset();
            cargarPerfiles();
        } else {
            mostrarAlerta(await res.text(), "danger");
        }
    });
});

async function cargarPerfiles() {
    try {
        const res = await fetch(API_PERFILES);
        cachePerfiles = await res.json();
        renderizarTabla();
    } catch (error) {
        console.error("Error al recuperar los perfiles:", error);
    }
}

function renderizarTabla() {
    const cuerpoTabla = document.getElementById('tablaCuerpo');
    cuerpoTabla.innerHTML = "";

    if (cachePerfiles.length === 0) {
        cuerpoTabla.innerHTML = `<tr><td colspan="4" class="text-center text-muted py-3">No existen perfiles registrados.</td></tr>`;
        return;
    }

    cachePerfiles.forEach(p => {
        const codPerfil = p.codigo ? p.codigo.trim() : "";
        const nomPerfil = p.nombre ? p.nombre.trim() : "";
        const descPerfil = p.descripcion ? p.descripcion.trim() : "";

        cuerpoTabla.innerHTML += `
            <tr>
                <td class="fw-bold text-secondary">${codPerfil}</td>
                <td class="fw-bold text-primary">${nomPerfil}</td>
                <td>${descPerfil}</td>
                <td class="text-center">
                    <button class="btn btn-sm btn-warning me-1 fw-semibold"
                        onclick="abrirModalEditar('${codPerfil}', '${nomPerfil}', '${descPerfil}')">
                        <i class="bi bi-pencil-fill"></i> Editar
                    </button>
                    <button class="btn btn-sm btn-danger fw-semibold"
                        onclick="ejecutarEliminacion('${codPerfil}')">
                        <i class="bi bi-trash-fill"></i> Eliminar
                    </button>
                </td>
            </tr>
        `;
    });
}

function abrirModalEditar(codigo, nombre, descripcion) {
    document.getElementById('editCodigoPerfil').value = codigo;
    document.getElementById('editNombrePerfil').value = nombre;
    document.getElementById('editDescripcionPerfil').value = descripcion;

    instanciaModal.show();
}

async function guardarEdicion() {
    const codigo = document.getElementById('editCodigoPerfil').value;
    const nombre = document.getElementById('editNombrePerfil').value.toUpperCase().trim();
    const descripcion = document.getElementById('editDescripcionPerfil').value.trim();

    const payload = {
        codigo: codigo,
        nombre: nombre,
        descripcion: descripcion
    };

    const res = await fetch(`${API_PERFILES}/${codigo}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
    });

    if (res.ok) {
        instanciaModal.hide();
        mostrarAlerta("Perfil actualizado de manera correcta.", "success");
        cargarPerfiles();
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

async function ejecutarEliminacion(codigo) {
    if (!confirm(`¿Está seguro de eliminar el perfil [${codigo}]?`)) return;

    const res = await fetch(`${API_PERFILES}/${codigo}`, { method: 'DELETE' });
    if (res.ok) {
        mostrarAlerta("Perfil removido de la base de datos de manera correcta.", "success");
        cargarPerfiles();
    } else {
        mostrarAlerta(await res.text(), "danger");
    }
}

function mostrarAlerta(mensaje, tipo) {
    const box = document.getElementById('alertGlobal');
    box.className = `alert alert-${tipo}`;
    box.textContent = mensaje;
    box.classList.remove('d-none');
    setTimeout(() => box.classList.add('d-none'), 4000);
}
