package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.OpcPer;
import ec.edu.monster.entidades.jpa.OpcPerId;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface OpcPerRepositorio extends JpaRepository<OpcPer, OpcPerId>{

    @Query("SELECT DISTINCT o FROM OpcPer o "
         + "LEFT JOIN FETCH o.opcion op "
         + "LEFT JOIN FETCH op.sistema "
         + "WHERE o.perfil.codigo = ?1")
    List<OpcPer> findByPerfilCodigoWithOpcionSistema(String perfilCodigo);

    @Query("SELECT DISTINCT o FROM OpcPer o "
         + "LEFT JOIN FETCH o.opcion op "
         + "LEFT JOIN FETCH op.sistema "
         + "WHERE o.perfil.codigo = ?1 AND o.opcion.codigo = ?2")
    java.util.Optional<OpcPer> findByPerfilCodigoAndOpcionCodigo(String perfilCodigo, String opcionCodigo);
}
