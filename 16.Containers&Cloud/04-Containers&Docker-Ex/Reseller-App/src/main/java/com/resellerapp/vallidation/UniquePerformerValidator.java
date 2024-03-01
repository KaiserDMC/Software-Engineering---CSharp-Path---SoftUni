package com.resellerapp.vallidation;

import com.resellerapp.service.OfferServiceImpl;
import com.resellerapp.vallidation.annotation.UniquePerformer;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

public class UniquePerformerValidator implements ConstraintValidator<UniquePerformer, String> {

    private final OfferServiceImpl songService;

    public UniquePerformerValidator(OfferServiceImpl songService) {
        this.songService = songService;
    }

    @Override
    public boolean isValid(String value, ConstraintValidatorContext context) {
        return false;
    }
}
