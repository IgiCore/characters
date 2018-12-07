window.CharacterSelect = {
	name: 'CharacterSelect',

	template: '#character-select-template',

	components: {
		Character: window.Character
	},

	data() {
		return {
			newCharacter: {
				forename: '',
				middlename: '',
				surname: '',
				gender: 0,
				dob: '1999-01-01'
			}
		}
	},

	computed: {
		...Vuex.mapGetters([
			'characters'
		])
	},

	methods: {
		async submitNew() {
			//await Nui.send('character-create', this.newCharacter)

			$(this.$refs.newModal).modal('hide')

			this.newCharacter = {
				forename: '',
				middlename: '',
				surname: '',
				gender: 0,
				dob: '1999-01-01'
			}
		},

		async selectCharacter(id) {
			await this.$store.dispatch('selectCharacter', id)

			this.$emit('select')
		},

		async deleteCharacter(id) {
			await this.$store.dispatch('deleteCharacter', id)
		},

		disconnect() {
			$(this.$refs.disconnectModal).modal('hide')

			this.$emit('disconnect')
		}
	}
};
