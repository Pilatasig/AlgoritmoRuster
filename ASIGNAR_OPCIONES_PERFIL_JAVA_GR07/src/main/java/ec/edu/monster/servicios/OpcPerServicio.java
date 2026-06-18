package ec.edu.monster.servicios;

import ec.edu.monster.entidades.OpcPer;
import ec.edu.monster.entidades.Opcion;
import ec.edu.monster.entidades.Perfil;
import ec.edu.monster.entidades.Sistema;
import ec.edu.monster.repositorio.OpcPerRepositorio;
import ec.edu.monster.repositorio.OpcionRepositorio;
import ec.edu.monster.repositorio.PerfilRepositorio;
import ec.edu.monster.repositorio.SistemaRepositorio;
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