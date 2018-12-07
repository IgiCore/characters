window.Character = {
	name: 'Character',

	template: '#character-template',

	props: {
		character: {
			type: Object,
			required: true
		}
	},

	methods: {
		deleteCharacter() {
			this.$emit('delete', this.character.Id)

			$(this.$refs.deleteModal).modal('hide')
		}
	}
};
