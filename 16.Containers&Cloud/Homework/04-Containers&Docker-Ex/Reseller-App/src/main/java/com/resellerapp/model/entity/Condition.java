package com.resellerapp.model.entity;

import javax.persistence.*;
import java.util.Set;

@Entity
@Table(name = "conditions")
public class Condition extends BaseEntity {

    @Enumerated(EnumType.STRING)
    private ConditionEnum conditionName;
    @Column
    private String description;

    @OneToMany(mappedBy = "condition")
    private Set<Offer> offers;

    public Condition() {
    }

    public ConditionEnum getConditionName() {
        return conditionName;
    }

    public Condition setConditionName(ConditionEnum moodName) {
        this.conditionName = moodName;
        return this;
    }

    public String getDescription() {
        return description;
    }

    public Condition setDescription(String description) {
        this.description = description;
        return this;
    }


    public Set<Offer> getOffers() {
        return offers;
    }

    public Condition setOffers(Set<Offer> offers) {
        this.offers = offers;
        return this;
    }
}
