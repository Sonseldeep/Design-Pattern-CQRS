using LearnCQRS.Application.Features.Profiles.Commands.CreateAdminProfile;
using LearnCQRS.Application.Features.Profiles.DTOs;
using LearnCQRS.Application.Features.Profiles.Queries.ListProfiles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnCQRS.Api.Controllers.Profies;

[Route("users/{userId:guid}/profiles")]
public class ProfilesController(ISender _mediator) : ApiController
{
    // Only authenticated Admins can assign Admin profile
    [HttpPost("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAdminProfile(Guid userId)
    {
        var command = new CreateAdminProfileCommand(userId);

        var createProfileResult = await _mediator.Send(command);

        return createProfileResult.Match(
            id => Ok(new ProfileResponse(id)),
            Problem);
    }

    // Allow authenticated users; handler will check Admin or same-user
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ListProfiles(Guid userId)
    {
        var listProfilesQuery = new ListProfilesQuery(userId);

        var listProfilesResult = await _mediator.Send(listProfilesQuery);

        return listProfilesResult.Match(
            profiles => Ok(new ListProfilesResponse(
                profiles.AdminId,
                profiles.ParticipantId,
                profiles.TrainerId)),
            Problem);
    }
}