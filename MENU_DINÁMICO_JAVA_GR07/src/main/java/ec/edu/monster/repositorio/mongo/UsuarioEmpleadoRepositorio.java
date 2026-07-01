package ec.edu.monster.repositorio.mongo;

import ec.edu.monster.entidades.mongo.UsuarioEmpleadoDocumento;
import java.util.Optional;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UsuarioEmpleadoRepositorio extends MongoRepository<UsuarioEmpleadoDocumento, String> {
    Optional<UsuarioEmpleadoDocumento> findByUsername(String username);
}
