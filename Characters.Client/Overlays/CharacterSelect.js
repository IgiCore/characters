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
				dateofbirth: '1999-01-01'
			}
		}
	},

	computed: {
		...Vuex.mapGetters([
			'characters'
		])
	},

	mounted() {
		nfive.on('load', async (characters) => {
			await this.$store.dispatch('setCharacters', characters)

			nfive.show()
		})

		nfive.send('load')
	},

	beforeDestroy() {

	},

	methods: {
		async selectCharacter(id) {
			await this.$store.dispatch('selectCharacter', id)

			nfive.send('select', id)
		},

		async deleteCharacter(id) {
			await this.$store.dispatch('deleteCharacter', id)

			nfive.send('delete', id)
		},

		async disconnect() {
			$(this.$refs.disconnectModal).modal('hide')

			nfive.send('disconnect')
		},

		async submitNew() {
			nfive.send('create', this.newCharacter)

			$(this.$refs.newModal).modal('hide')

			this.newCharacter = {
				forename: '',
				middlename: '',
				surname: '',
				gender: 0,
				dob: '1999-01-01'
			}
		}
	}
};
