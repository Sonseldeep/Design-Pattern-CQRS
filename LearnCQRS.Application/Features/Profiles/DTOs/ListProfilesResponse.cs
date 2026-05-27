namespace LearnCQRS.Application.Features.Profiles.DTOs;

public record ListProfilesResponse(Guid? AdminId, Guid? ParticipantId, Guid? TrainerId);