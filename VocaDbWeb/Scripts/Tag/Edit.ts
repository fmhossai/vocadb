import RepositoryFactory from '@Repositories/RepositoryFactory';
import UrlMapper from '@Shared/UrlMapper';
import vdb from '@Shared/VdbStatic';
import { container } from '@Shared/inversify.config';
import TagEditViewModel from '@ViewModels/TagEditViewModel';
import $ from 'jquery';
import ko from 'knockout';

function initPage(): void {
	$('#trashLink').button({ icons: { primary: 'ui-icon-trash' } });
	$('#deleteLink').button({ icons: { primary: 'ui-icon-trash' } });
	$('#restoreLink').button({ icons: { primary: 'ui-icon-trash' } });
}

const TagEdit = (model: { id: number }): void => {
	$(document).ready(function () {
		initPage();

		var urlMapper = new UrlMapper(vdb.values.baseAddress);
		const repoFactory = container.get(RepositoryFactory);
		var tagRepo = repoFactory.tagRepository();
		var userRepo = repoFactory.userRepository();

		tagRepo
			.getById(
				model.id,
				'AliasedTo,TranslatedDescription,Names,Parent,RelatedTags,WebLinks',
				vdb.values.languagePreference,
			)
			.then(function (contract) {
				var viewModel = new TagEditViewModel(urlMapper, userRepo, contract);
				ko.applyBindings(viewModel);
			});
	});
};

export default TagEdit;
