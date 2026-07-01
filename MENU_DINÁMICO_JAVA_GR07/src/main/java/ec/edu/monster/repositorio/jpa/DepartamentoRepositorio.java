package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.Departamento;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DepartamentoRepositorio extends JpaRepository<Departamento, String> {
    
}