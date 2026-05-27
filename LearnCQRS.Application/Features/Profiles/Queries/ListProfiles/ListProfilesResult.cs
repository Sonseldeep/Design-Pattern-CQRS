namespace LearnCQRS.Application.Features.Profiles.Queries.ListProfiles;

public record ListProfilesResult(Guid? AdminId, Guid? ParticipantId, Guid? TrainerId);