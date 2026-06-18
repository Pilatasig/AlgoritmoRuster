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
        mostrarAlerta('Error al cargar perfiles. Revise la consola.', 'danger');
    }
}

async function cargarArbol() {
    const codigoPerfil = document.getElementById('selectPerfil').value;
    if (!codigoPerfil) {
        mostrarAlerta('Debe seleccionar un perfil.', 'warning');
        return;
    }

    try {
        const res = await fetch(`${API_BASE}/opciones-perfil/${codigoPerfil}`);
        if (!res.ok) {
            mostrarAlerta('Error al obtener opciones: ' + (await res.text()), 'danger');
            return;
        }
        const arbol = await res.json();

        const container = document.getElementById('arbolContainer');
        const panel = document.getElementById('panelArbol');
        const btnGuardar = document.getElementById('btnGuardar');

        container.innerHTML = '';
        panel.style.display = 'block';
        btnGuardar.style.display = 'block';

        arbol.forEach(sis => {
            const sisDiv = crearNodoSistema(sis);
            container.appendChild(sisDiv);

            if (sis.modulos) {
                const modulosDiv = document.createElement('div');
                modulosDiv.className = 'tree-opciones';
                modulosDiv.style.display = 'none';

                sis.modulos.forEach(mod => {
                    const modDiv = crearNodoModulo(mod, codigoPerfil);
                    modulosDiv.appendChild(modDiv);
                });

                container.appendChild(modulosDiv);

                sisDiv.addEventListener('click', (e) => {
                    if (e.target.closest('.hija-chk')) return;
                    const isHidden = modulosDiv.style.display === 'none';
                    modulosDiv.style.display = isHidden ? 'block' : 'none';
                    sisDiv.querySelector('.toggle-icon').classList.toggle('collapsed', !isHidden);
                });
            }
        });
    } catch (e) {
        console.error('Error cargando arbol:', e);
        mostrarAlerta('Error de conexi\u00f3n al cargar opciones.', 'danger');
    }
}

function crearNodoSistema(sis) {
    const div = document.createElement('div');
    div.className = 'tree-sistema d-flex align-items-center justify-content-between';
    div.innerHTML = `
        <span><i class="bi bi-folder-fill text-primary me-2"></i> ${sis.descripcion} (${sis.codigo})</span>
        <span class="toggle-icon bi bi-chevron-down"></span>
    `;
    return div;
}

function crearNodoModulo(mod, codigoPerfil) {
    const div = document.createElement('div');
    div.className = 'tree-modulo';

    const header = document.createElement('div');
    header.className = 'tree-modulo-header d-flex align-items-center justify-content-between';
    header.innerHTML = `
        <span><i class="bi bi-folder2-open text-success me-2"></i> <strong>${mod.descripcion}</strong></span>
        <span class="toggle-icon-mod bi bi-chevron-down"></span>
    `;
    div.appendChild(header);

    const hijasDiv = document.createElement('div');
    hijasDiv.className = 'tree-hijas';
    hijasDiv.style.display = 'none';

    if (mod.hijas) {
        mod.hijas.forEach(hija => {
            const hijaDiv = document.createElement('div');
            hijaDiv.className = 'tree-hija d-flex align-items-center py-1';
            hijaDiv.innerHTML = `
                <input type="checkbox" class="hija-chk me-2" data-perfil="${codigoPerfil}" data-opcion="${hija.codigo}" ${hija.asignada ? 'checked' : ''}>
                <i class="bi bi-file-earmark-text me-2 text-secondary"></i>
                <span>${hija.descripcion}</span>
            `;
            hijasDiv.appendChild(hijaDiv);

            hijaDiv.querySelector('.hija-chk').addEventListener('change', () => {
                marcarEstadoPendiente();
            });
        });
    }
    div.appendChild(hijasDiv);

    header.addEventListener('click', (e) => {
        if (e.target.closest('.hija-chk')) return;
        const isHidden = hijasDiv.style.display === 'none';
        hijasDiv.style.display = isHidden ? 'block' : 'none';
        header.querySelector('.toggle-icon-mod').classList.toggle('collapsed', !isHidden);
    });

    return div;
}

function marcarEstadoPendiente() {
    const btnGuardar = document.getElementById('btnGuardar');
    btnGuardar.classList.remove('btn-success');
    btnGuardar.classList.add('btn-warning');
}

async function guardarAsignaciones() {
    const codigoPerfil = document.getElementById('selectPerfil').value;
    if (!codigoPerfil) {
        mostrarAlerta('Debe seleccionar un perfil.', 'warning');
        return;
    }

    const asignar = [];
    const remover = [];

    document.querySelectorAll('.hija-chk').forEach(cb => {
        const opcion = cb.dataset.opcion;
        if (cb.checked) {
            asignar.push(opcion);
        } else {
            remover.push(opcion);
        }
    });

    try {
        const res = await fetch(`${API_BASE}/opciones-perfil/${codigoPerfil}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ asignar, remover })
        });
        if (res.ok) {
            mostrarAlerta('Asignaciones guardadas exitosamente.', 'success');
            const btnGuardar = document.getElementById('btnGuardar');
            btnGuardar.classList.remove('btn-warning');
            btnGuardar.classList.add('btn-success');
        } else {
            mostrarAlerta(await res.text(), 'danger');
        }
    } catch (e) {
        console.error('Error guardando asignaciones:', e);
        mostrarAlerta('Error de conexi\u00f3n al guardar.', 'danger');
    }
}

function mostrarAlerta(mensaje, tipo) {
    const box = document.getElementById('alertGlobal');
    box.className = 'alert alert-' + tipo;
    box.textContent = mensaje;
    box.classList.remove('d-none');
    setTimeout(() => box.classList.add('d-none'), 4000);
}