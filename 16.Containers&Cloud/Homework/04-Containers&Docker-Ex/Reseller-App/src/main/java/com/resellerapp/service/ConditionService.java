package com.resellerapp.service;

import com.resellerapp.model.entity.Condition;
import com.resellerapp.model.entity.ConditionEnum;

public interface ConditionService {

    void initConditions();

    Condition findCondition(ConditionEnum style);

    Condition findStyleByStyleName(ConditionEnum styleName);
}
