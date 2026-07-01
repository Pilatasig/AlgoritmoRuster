package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.Usuario;
import java.util.List;
import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface UsuarioRepositorio extends JpaRepository<Usuario, String>{

    Optional<Usuario> findByEmpleadoCodigo(String empleadoCodigo);

    @Query("SELECT DISTINCT u FROM Usuario u "
         + "LEFT JOIN FETCH u.empleado "
         + "LEFT JOIN FETCH u.estado "
         + "WHERE u.id NOT IN (SELECT us.usuario.id FROM Usuper us WHERE us.perfil.codigo = ?1)")
    List<Usuario> findUsuariosNotInPerfil(String perfilCodigo);

    @Query("SELECT DISTINCT u FROM Usuario u LEFT JOIN FETCH u.empleado LEFT JOIN FETCH u.estado")
    List<Usuario> findAllWithEmpleado();
}
