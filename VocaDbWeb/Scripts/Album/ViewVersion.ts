import RepositoryFactory from '@Repositories/RepositoryFactory';
import { container } from '@Shared/inversify.config';
import ArchivedAlbumViewModel from '@ViewModels/Album/ArchivedAlbumViewModel';
import $ from 'jquery';
import ko from 'knockout';

const AlbumViewVersion = (model: {
	album: {
		id: number;
	};
	archivedVersion: {
		version: number;
	};
}): void => {
	$(function () {
		$('#revertLink').button({ icons: { primary: 'ui-icon-arrowrefresh-1-w' } });
		$('#downloadXmlLink').button({
			icons: { primary: 'ui-icon-arrowthickstop-1-s' },
		});
		$('#reportEntryLink').button({ icons: { primary: 'ui-icon-alert' } });
		$('#showLink').button({ icons: { primary: 'ui-icon-unlocked' } });
		$('#hideLink').button({ icons: { primary: 'ui-icon-locked' } });

		const repoFactory = container.get(RepositoryFactory);
		var rep = repoFactory.albumRepository();

		var viewModel = new ArchivedAlbumViewModel(
			model.album.id,
			model.archivedVersion.version,
			rep,
		);
		ko.applyBindings(viewModel);
	});
};

export default AlbumViewVersion;
