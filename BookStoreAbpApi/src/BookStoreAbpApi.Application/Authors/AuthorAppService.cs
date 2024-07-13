using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAbpApi.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace BookStoreAbpApi.Authors
{

    [Authorize(BookStoreAbpApiPermissions.Authors.Default)]
    public class AuthorAppService : BookStoreAbpApiAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }



        [Authorize(BookStoreAbpApiPermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(input.Name, input.BirthDate, input.ShortBio);
            var insertedAuthor = await _authorRepository.InsertAsync(author, autoSave:true);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }


        [Authorize(BookStoreAbpApiPermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id) 
            => await _authorRepository.DeleteAsync(id, autoSave: true);

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id, includeDetails: true);
            return ObjectMapper.Map<Author, AuthorDto>(author);

        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }


            var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(totalCount, ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors ?? []));
        }


        [Authorize(BookStoreAbpApiPermissions.Authors.Update)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id, includeDetails:true);

            if (author.Name != input.Name)
            {
               await _authorManager.ChangeNameAsync(author, input.Name);
            }

            author.ShortBio = input.ShortBio;
            author.BirthDate = input.BirthDate;

            await _authorRepository.UpdateAsync(author, autoSave:true);
            
            
        }
    }
}