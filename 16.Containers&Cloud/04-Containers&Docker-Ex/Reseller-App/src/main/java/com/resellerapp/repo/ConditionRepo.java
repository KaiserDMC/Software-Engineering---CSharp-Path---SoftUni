package com.resellerapp.repo;

import com.resellerapp.model.entity.Condition;
import com.resellerapp.model.entity.ConditionEnum;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface ConditionRepo extends JpaRepository<Condition, Long> {

    Optional<Condition> findByConditionName(ConditionEnum conditionEnum);
}
