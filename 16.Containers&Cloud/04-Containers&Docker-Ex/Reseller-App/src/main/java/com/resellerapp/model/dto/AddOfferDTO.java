package com.resellerapp.model.dto;

import com.resellerapp.model.entity.ConditionEnum;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Positive;
import javax.validation.constraints.Size;

public class AddOfferDTO {
    private Long id;

    @Size(min = 2, max = 50, message = "Description length must be between 2 and 50 characters!")
    @NotNull
    private String description;

    @NotNull(message = "You must select a condition!")
    private ConditionEnum condition;

    @NotNull(message = "Can't be empty!")
    @Positive(message = "Price must be positive number!")
    private Double price;

    public AddOfferDTO() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public ConditionEnum getCondition() {
        return condition;
    }

    public void setCondition(ConditionEnum condition) {
        this.condition = condition;
    }

    public String getDescription() {
        return description;
    }

    public AddOfferDTO setDescription(String description) {
        this.description = description;
        return this;
    }

    public Double getPrice() {
        return price;
    }

    public AddOfferDTO setPrice(Double price) {
        this.price = price;
        return this;
    }
}
