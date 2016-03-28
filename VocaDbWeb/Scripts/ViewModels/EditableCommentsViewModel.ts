﻿
module vdb.viewModels {
	
	import dc = vdb.dataContracts;
	import rep = vdb.repositories;

	// Viewmodel for a list of comments where comments can be edited and new comments posted (with sufficient permissions).
	export class EditableCommentsViewModel {

		constructor(
			private repo: rep.ICommentRepository,			
			private entryId: number,
			private loggedUserId: number,
			private canDeleteAllComments: boolean,
			private canEditAllComments: boolean,
			private ascending: boolean,
			commentContracts?: dc.CommentContract[],
			hasMoreComments: boolean = false) {
			
			this.comments = ko.observableArray<CommentViewModel>(null);
			this.commentsLoaded = commentContracts != null && !hasMoreComments;
			this.topComments = ko.computed(() => _.take(this.comments(), 3));

			if (commentContracts) {
				this.setComments(commentContracts);				
			}

		}
	
		public beginEditComment = (comment: CommentViewModel) => {

			comment.beginEdit();
			this.editCommentModel(comment);

		}

		public cancelEditComment = () => {
			this.editCommentModel(null);
		}

		private canDeleteComment = (comment: dc.CommentContract) => {
			// If one can edit they can also delete
			return (this.canDeleteAllComments || this.canEditAllComments || (comment.author && comment.author.id === this.loggedUserId));
		}

		private canEditComment = (comment: dc.CommentContract) => {
			return (this.canEditAllComments || (comment.author && comment.author.id === this.loggedUserId));
		}
			
		public comments: KnockoutObservableArray<CommentViewModel>;

		// Whether all comments have been loaded
		private commentsLoaded: boolean;

		public createComment = () => {

			var comment = this.newComment();

			if (!comment)
				return;

			this.newComment("");

			var commentContract: dc.CommentContract = {
				author: { id: this.loggedUserId },
				message: comment
			}

			this.repo.createComment(this.entryId, commentContract, result => {

				var processed = this.processComment(result);

				if (this.ascending)
					this.comments.push(processed);
				else
					this.comments.unshift(processed);

				if (this.onCommentCreated)
					this.onCommentCreated(_.clone(processed));

			});

		}

		public deleteComment = (comment: CommentViewModel) => {

			this.comments.remove(comment);

			this.repo.deleteComment(comment.id);

		}

		public editCommentModel = ko.observable<CommentViewModel>(null);

		public initComments = () => {

			if (this.commentsLoaded)
				return;

			this.repo.getComments(this.entryId, contracts => {
				this.setComments(contracts);				
			});

			this.commentsLoaded = true;

		}

		public newComment = ko.observable("");

		public onCommentCreated: (comment: CommentViewModel) => void;

		private processComment = (contract: dc.CommentContract) => {

			return new CommentViewModel(contract, this.canDeleteComment(contract), this.canEditComment(contract));

		}

		public saveEditedComment = () => {

			if (!this.editCommentModel())
				return;

			this.editCommentModel().saveChanges();
			var editedContract = this.editCommentModel().toContract();

			this.repo.updateComment(editedContract.id, editedContract);

			this.editCommentModel(null);

		}

		private setComments = (commentContracts: dc.CommentContract[]) => {
			
			var commentViewModels = _.sortBy(_.map(commentContracts, comment => this.processComment(comment)), comment => comment.created);

			if (!this.ascending)
				commentViewModels = commentViewModels.reverse();

			this.comments(commentViewModels);

		}

		// Latest N comments
		public topComments: KnockoutComputed<CommentViewModel[]>;

	}

} 