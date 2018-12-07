window.App = {
	name: 'App',

	template: '#app-template',

	components: {
		CharacterSelect: window.CharacterSelect
	},

	data() {
		return {
			visible: true,
			screen: 'CharacterSelect'
		};
	},

	mounted() {
		nfive.on('load', async (characters) => {
			console.log(characters)

			await this.$store.dispatch('setCharacters', characters)

			nfive.show()
		});

		$(window).on('keypress', this.onKeypress);
	},

	beforeDestroy() {
		$(window).off('keypress', this.onKeypress);
	},

	methods: {
		onKeypress(e) {

		},

		async select() {
			this.visible = false;
			this.screen = 'Blank';
		},

		async disconnect() {
			//await Nui.send('disconnect');
		}
	}
};
