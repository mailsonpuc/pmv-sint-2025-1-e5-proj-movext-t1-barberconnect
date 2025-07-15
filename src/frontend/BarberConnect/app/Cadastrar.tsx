import { Link } from 'expo-router';
import { StyleSheet, Text, View } from 'react-native';
import { Button } from 'react-native-paper';

export default function Cadastrar() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Eu sou?</Text>

      <View style={styles.buttonGroup}>
        <Link href="/Usuario" asChild>
          <Button icon="account" mode="contained" style={styles.button}>
            Cliente
          </Button>
        </Link>

        <Link href="/Usuario" asChild>
          <Button icon="account-cowboy-hat" mode="contained" style={styles.button}>
            Barbeiro
          </Button>
        </Link>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 20,
    backgroundColor: '#fff',
  },
  title: {
    fontSize: 26,
    fontWeight: 'bold',
    marginBottom: 40,
    color: '#333',
  },
  buttonGroup: {
    gap: 20, // espaçamento entre botões (RN 0.71+)
    width: '100%',
    alignItems: 'center',
  },
  button: {
    width: 200,
    borderRadius: 10,
    paddingVertical: 5,
  },
});
