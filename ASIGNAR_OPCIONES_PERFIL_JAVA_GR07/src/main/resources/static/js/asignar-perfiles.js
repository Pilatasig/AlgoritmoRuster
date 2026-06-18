const API_BASE = window.location.origin + '/api';

document.addEventListener('DOMContentLoaded', () => {
    cargarPerfilesEnCombo();
});

async function cargarPerfilesEnCombo() {
    try {
        const res = await fetch(API_BASE + '/perfiles');
        const perfiles = await res.json();
        const combo = document.getElementById('selectPerfil');
        perfiles.forEach(p => {
            const opt = document.createElement('option');
            opt.value = p.codigo.trim();
            opt.textContent = p.codigo.trim() + ' - ' + (p.nombre ? p.nombre.trim() : '') + ' - ' + (p.descripcion ? p.descripcion.trim() : '');
            combo.appendChild(opt);
        });
    } catch (e) {
        console.error('Error cargando perfiles:', e);
    }
}

async function cargarAsignaciones() {
    const codigoPerfil = document.getElementById('selectPerfil').value;
    if (!codigoPerfil) {
        mostrarAlerta('Debe seleccionar un perfil para consultar.', 'warning');
        return;
    }

    document.getElementById('panelesAsignacion').style.display = 'flex';

    await Promise.all([
        cargarTablaAsignados(codigoPerfil),
        cargarTablaDisponibles(codigoPerfil)
    ]);
}

async function cargarTablaAsignados(codigoPerfil) {
    try {
        const res = await fetch(`${API_BASE}/asignar-perfiles/${codigoPerfil}/asignados`);
        if (!res.ok) {
            mostrarAlerta('Error al consultar usuarios asignados: ' + (await res.text()), 'danger');
            return;
        }
        const data = await res.json();

        const tbody = document.getElementById('tablaAsignados');
        const empty = document.getElementById('emptyAsignados');
        const badge = document.getElementById('badgeAsignados');

        tbody.innerHTML = '';
        badge.textContent = data.length;

        if (data.length === 0) {
            empty.style.display = 'block';
            return;
        }
        empty.style.display = 'none';

        data.forEach(item => {
            const u = item.usuario;
            if (!u) return;
            const emp = u.empleado || {};
            tbody.innerHTML += `
                <tr>
                    <td class="fw-bold small">${u.id}</td>
                    <td>${emp.apellidos || ''}</td>
                    <td>${emp.nombres || ''}</td>
                    <td class="text-center">
                        <button class="btn btn-sm btn-outline-danger"
                            onclick="removerUsuario('${codigoPerfil}', '${u.id}')"
                            title="Remover perfil">
                            <i class="bi bi-x-circle"></i>
                        </button>
                    </td>
                </tr>
            `;
        });
    } catch (e) {
        console.error('Error cargando asignados:', e);
        mostrarAlerta('Error de conexi\u00f3n al cargar asignados.', 'danger');
    }
}

async function cargarTablaDisponibles(codigoPerfil) {
    try {
        const res = await fetch(`${API_BASE}/asignar-perfiles/${codigoPerfil}/disponibles`);
        if (!res.ok) {
            mostrarAlerta('Error al consultar usuarios disponibles: ' + (await res.text()), 'danger');
            return;
        }
        const data = await res.json();

        const tbody = document.getElementById('tablaDisponibles');
        const empty = document.getElementById('emptyDisponibles');
        const badge = document.getElementById('badgeDisponibles');

        tbody.innerHTML = '';
        badge.textContent = data.length;

        if (data.length === 0) {
            empty.style.display = 'block';
            return;
        }
        empty.style.display = 'none';

        data.forEach(u => {
            const emp = u.empleado || {};
            tbody.innerHTML += `
                <tr>
                    <td class="fw-bold small">${u.id}</td>
                    <td>${emp.apellidos || ''}</td>
                    <td>${emp.nombres || ''}</td>
                    <td class="text-center">
                        <button class="btn btn-sm btn-outline-success"
                            onclick="asignarUsuario('${codigoPerfil}', '${u.id}')"
                            title="Asignar perfil">
                            <i class="bi bi-plus-circle"></i>
                        </button>
                    </td>
                </tr>
            `;
        });
    } catch (e) {
        console.error('Error cargando disponibles:', e);
        mostrarAlerta('Error de conexi\u00f3n al cargar disponibles.', 'danger');
    }
}

async function asignarUsuario(codigoPerfil, usuarioId) {
    const res = await fetch(`${API_BASE}/asignar-perfiles/${codigoPerfil}/asignar/${usuarioId}`, {
        method: 'POST'
    });
    if (res.ok) {
        mostrarAlerta('Usuario asignado al perfil exitosamente.', 'success');
        await Promise.all([
            cargarTablaAsignados(codigoPerfil),
            cargarTablaDisponibles(codigoPerfil)
        ]);
    } else {
        mostrarAlerta(await res.text(), 'danger');
    }
}

async function removerUsuario(codigoPerfil, usuarioId) {
    if (!confirm('¿Está seguro de remover este usuario del perfil?')) return;

    const res = await fetch(`${API_BASE}/asignar-perfiles/${codigoPerfil}/remover/${usuarioId}`, {
        method: 'DELETE'
    });
    if (res.ok) {
        mostrarAlerta('Usuario removido del perfil exitosamente.', 'success');
        await Promise.all([
            cargarTablaAsignados(codigoPerfil),
            cargarTablaDisponibles(codigoPerfil)
        ]);
    } else {
        mostrarAlerta(await res.text(), 'danger');
    }
}

function mostrarAlerta(mensaje, tipo) {
    const box = document.getElementById('alertGlobal');
    box.className = `alert alert-${tipo}`;
    box.textContent = mensaje;
    box.classList.remove('d-none');
    setTimeout(() => box.classList.add('d-none'), 4000);
}
