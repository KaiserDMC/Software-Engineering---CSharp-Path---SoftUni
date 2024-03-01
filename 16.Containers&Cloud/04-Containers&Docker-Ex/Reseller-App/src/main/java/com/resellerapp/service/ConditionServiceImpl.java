package com.resellerapp.service;

import com.resellerapp.model.entity.Condition;
import com.resellerapp.model.entity.ConditionEnum;
import com.resellerapp.repo.ConditionRepo;
import org.springframework.stereotype.Service;

import java.util.Arrays;

@Service
public class ConditionServiceImpl implements ConditionService {

    private final ConditionRepo conditionRepo;

    public ConditionServiceImpl(ConditionRepo conditionRepo) {
        this.conditionRepo = conditionRepo;
    }

    @Override
    public void initConditions() {
        if (this.conditionRepo.count() != 0) {
            return;
        }

        Arrays.stream(ConditionEnum.values())
                .forEach(s -> {
                    Condition condition = new Condition();
                    condition.setConditionName(s);
                    condition.setDescription("...");

                    this.conditionRepo.save(condition);
                });

    }

    @Override
    public Condition findCondition(ConditionEnum conditionEnum) {
        return this.conditionRepo.findByConditionName(conditionEnum).orElseThrow();
    }

    @Override
    public Condition findStyleByStyleName(ConditionEnum styleName) {
        return this.conditionRepo.findByConditionName(styleName).orElseThrow();
    }
}
