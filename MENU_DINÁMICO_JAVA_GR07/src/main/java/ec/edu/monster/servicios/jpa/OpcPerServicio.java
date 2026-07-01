package ec.edu.monster.servicios.jpa;

import ec.edu.monster.entidades.jpa.OpcPer;
import ec.edu.monster.entidades.jpa.Opcion;
import ec.edu.monster.entidades.jpa.Perfil;
import ec.edu.monster.entidades.jpa.Sistema;
import ec.edu.monster.entidades.jpa.Usuper;
import ec.edu.monster.repositorio.jpa.OpcPerRepositorio;
import ec.edu.monster.repositorio.jpa.OpcionRepositorio;
import ec.edu.monster.repositorio.jpa.PerfilRepositorio;
import ec.edu.monster.repositorio.jpa.SistemaRepositorio;
import ec.edu.monster.repositorio.jpa.UsuperRepositorio;
import java.util.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class OpcPerServicio {

    @Autowired
    private SistemaRepositorio sistemaRepo;

    @Autowired
    private OpcionRepositorio opcionRepo;

    @Autowired
    private OpcPerRepositorio opcPerRepo;

    @Autowired
    private PerfilRepositorio perfilRepo;

    @Autowired
    private UsuperRepositorio usuperRepo;

    @Transactional(readOnly = true)
    public List<Map<String, Object>> obtenerArbolOpciones(String perfilCodigo) {
        List<Sistema> sistemas = sistemaRepo.findAll();

        Set<String> opcionesAsignadas = opcPerRepo
            .findByPerfilCodigoWithOpcionSistema(perfilCodigo)
            .stream()
            .map(op -> op.getOpcion().getCodigo())
            .collect(java.util.stream.Collectors.toSet());

        List<Map<String, Object>> arbol = new ArrayList<>();

        for (Sistema sis : sistemas) {
            Map<String, Object> nodoSis = new LinkedHashMap<>();
            nodoSis.put("codigo", sis.getCodigo());
            nodoSis.put("descripcion", sis.getDescripcion());

            List<Opcion> padres = opcionRepo.findPadresBySistemaCodigo(sis.getCodigo());
            List<Map<String, Object>> listaPadres = new ArrayList<>();

            for (Opcion padre : padres) {
                Map<String, Object> nodoPadre = new LinkedHashMap<>();
                nodoPadre.put("codigo", padre.getCodigo());
                nodoPadre.put("descripcion", padre.getDescripcion());

                List<Opcion> hijas = opcionRepo.findByPadreCodigo(padre.getCodigo());
                List<Map<String, Object>> listaHijas = new ArrayList<>();

                for (Opcion hija : hijas) {
                    Map<String, Object> nodoHija = new LinkedHashMap<>();
                    nodoHija.put("codigo", hija.getCodigo());
                    nodoHija.put("descripcion", hija.getDescripcion());
                    nodoHija.put("asignada", opcionesAsignadas.contains(hija.getCodigo()));
                    listaHijas.add(nodoHija);
                }
                nodoPadre.put("hijas", listaHijas);
                listaPadres.add(nodoPadre);
            }
            nodoSis.put("modulos", listaPadres);
            arbol.add(nodoSis);
        }
        return arbol;
    }

    @Transactional(readOnly = true)
    public Set<String> obtenerPermisosUsuario(String usuarioCodigo) {
        List<Usuper> usupers = usuperRepo.findByUsuarioId(usuarioCodigo);
        if (usupers.isEmpty()) return Collections.emptySet();

        Set<String> permisos = new HashSet<>();
        for (Usuper u : usupers) {
            List<OpcPer> opcPers = opcPerRepo.findByPerfilCodigoWithOpcionSistema(u.getPerfil().getCodigo());
            for (OpcPer op : opcPers) {
                if (op.getFechaRetiro() == null) {
                    permisos.add(op.getOpcion().getCodigo());
                }
            }
        }
        return permisos;
    }

    @Transactional(readOnly = true)
    public Set<String> obtenerMenusPermitidos(String usuarioCodigo) {
        List<Usuper> usupers = usuperRepo.findByUsuarioId(usuarioCodigo);
        if (usupers.isEmpty()) return Collections.emptySet();

        Set<String> assignedChildCodes = new HashSet<>();
        for (Usuper u : usupers) {
            List<OpcPer> opcPers = opcPerRepo.findByPerfilCodigoWithOpcionSistema(u.getPerfil().getCodigo());
            for (OpcPer op : opcPers) {
                if (op.getFechaRetiro() == null) {
                    assignedChildCodes.add(op.getOpcion().getCodigo());
                }
            }
        }

        Set<String> parentCodes = new LinkedHashSet<>();
        for (String childCode : assignedChildCodes) {
            opcionRepo.findById(childCode).ifPresent(child -> {
                if (child.getPadre() != null) {
                    parentCodes.add(child.getPadre().getCodigo());
                }
            });
        }
        return parentCodes;
    }

    @Transactional
    public void guardarAsignaciones(String perfilCodigo, Map<String, Object> cuerpo) {
        Perfil perfil = perfilRepo.findById(perfilCodigo)
                .orElseThrow(() -> new RuntimeException("Perfil no encontrado: " + perfilCodigo));

        @SuppressWarnings("unchecked")
        List<String> opcionesAsignar = ((List<String>) cuerpo.getOrDefault("asignar", Collections.emptyList()));
        @SuppressWarnings("unchecked")
        List<String> opcionesRemover = ((List<String>) cuerpo.getOrDefault("remover", Collections.emptyList()));

        for (String codigo : opcionesAsignar) {
            Optional<OpcPer> existente = opcPerRepo.findByPerfilCodigoAndOpcionCodigo(perfilCodigo, codigo);
            if (existente.isEmpty()) {
                Opcion opcion = opcionRepo.findById(codigo)
                        .orElseThrow(() -> new RuntimeException("Opción no encontrada: " + codigo));
                OpcPer nuevo = new OpcPer();
                nuevo.setOpcion(opcion);
                nuevo.setPerfil(perfil);
                nuevo.setFechaAsignacion(new Date());
                opcPerRepo.save(nuevo);
            }
        }

        for (String codigo : opcionesRemover) {
            opcPerRepo.findByPerfilCodigoAndOpcionCodigo(perfilCodigo, codigo)
                    .ifPresent(opcPerRepo::delete);
        }
    }
}