package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Usuper;
import ec.edu.monster.entidades.UsuperId;
import java.util.List;
import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface UsuperRepositorio extends JpaRepository<Usuper, UsuperId> {

    @Query("SELECT DISTINCT u FROM Usuper u "
         + "LEFT JOIN FETCH u.usuario us "
         + "LEFT JOIN FETCH us.empleado "
         + "LEFT JOIN FETCH u.perfil "
         + "WHERE u.perfil.codigo = ?1")
    List<Usuper> findByPerfilCodigoWithUsuarioEmpleado(String perfilCodigo);

    Optional<Usuper> findByPerfilCodigoAndUsuarioId(String perfilCodigo, String usuarioId);

    long countByPerfilCodigo(String perfilCodigo);
}
