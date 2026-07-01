package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.Sexo;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface SexoRepositorio extends JpaRepository<Sexo, String> {
    
}
